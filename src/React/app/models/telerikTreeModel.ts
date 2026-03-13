export interface TelerikTreeModel {
  text: string;
  expanded?: boolean;
  imageId?: number;
  items?: TelerikTreeModel[];
  hasSubFolders: boolean;
  path: string;
}
