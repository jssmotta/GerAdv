'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TiposAcaoGrid from '@/app/GerAdv_TS/TiposAcao/Crud/Grids/TiposAcaoGrid';
export class TiposAcaoGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <TiposAcaoGrid />;
  }
}