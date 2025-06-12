'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import OperadorEMailPopupGrid from '@/app/GerAdv_TS/OperadorEMailPopup/Crud/Grids/OperadorEMailPopupGrid';
export class OperadorEMailPopupGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <OperadorEMailPopupGrid />;
  }
}