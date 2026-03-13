export interface IGridComponent {
  render(): React.ReactNode;  
  selectItem?: (item: any) => void;
}
