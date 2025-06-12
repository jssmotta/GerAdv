'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TipoEMailGrid from '@/app/GerAdv_TS/TipoEMail/Crud/Grids/TipoEMailGrid';
export class TipoEMailGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <TipoEMailGrid />;
  }
}