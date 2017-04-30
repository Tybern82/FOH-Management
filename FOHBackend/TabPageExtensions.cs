using System;
using System.Collections.Generic;
using System.Windows.Forms;

public static class TabPageExtensions {
    private struct TabPageData {
        internal int Index;
        internal TabControl Parent;
        internal TabPage Page;

        internal TabPageData(int index, TabControl parent, TabPage page) {
            Index = index;
            Parent = parent;
            Page = page;
        }

        internal static string GetKey(TabControl tabCtrl, TabPage tabPage) {
            string key = "";
            if (tabCtrl != null && tabPage != null) {
                key = String.Format("{0}:{1}", tabCtrl.Name, tabPage.Name);
            }
            return key;
        }
    }

    private static Dictionary<string, TabPageData> hiddenPages = new Dictionary<string, TabPageData>();

    public static void SetVisible(this TabPage page, TabControl parent) {
        if (parent != null && !parent.IsDisposed) {
            TabPageData tpinfo;

            string key = TabPageData.GetKey(parent, page);
            if (hiddenPages.ContainsKey(key)) {
                tpinfo = hiddenPages[key];
                if (tpinfo.Index < parent.TabPages.Count)
                    parent.TabPages.Insert(tpinfo.Index, tpinfo.Page); // add the page in the same position it had
                else
                    parent.TabPages.Add(tpinfo.Page);
                hiddenPages.Remove(key);
            }
        }
    }

    public static void SetInvisible(this TabPage page) {
        if (IsVisible(page)) {
            TabControl tabCtrl = (TabControl)page.Parent;
            TabPageData tpinfo;
            tpinfo = new TabPageData(tabCtrl.TabPages.IndexOf(page), tabCtrl, page);
            tabCtrl.TabPages.Remove(page);
            hiddenPages.Add(TabPageData.GetKey(tabCtrl, page), tpinfo);
        }
    }

    public static bool IsVisible(this TabPage page) {
        return page != null && page.Parent != null; // when Parent is null the tab page does not belong to any container
    }

    public static void CleanUpHiddenPages(this TabPage page) {
        foreach (TabPageData info in hiddenPages.Values) {
            if (info.Parent != null && info.Parent.Equals((TabControl)page.Parent))
                info.Page.Dispose();
        }
    }
}
