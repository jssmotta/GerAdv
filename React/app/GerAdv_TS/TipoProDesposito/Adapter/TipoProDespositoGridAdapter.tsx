'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TipoProDespositoGrid from '@/app/GerAdv_TS/TipoProDesposito/Crud/Grids/TipoProDespositoGrid';
export class TipoProDespositoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <TipoProDespositoGrid />;
  }
}