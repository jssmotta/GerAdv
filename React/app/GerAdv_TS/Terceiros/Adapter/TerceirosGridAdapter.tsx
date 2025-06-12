'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import TerceirosGrid from '@/app/GerAdv_TS/Terceiros/Crud/Grids/TerceirosGrid';
export class TerceirosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <TerceirosGrid />;
  }
}