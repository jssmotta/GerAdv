'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import DocsRecebidosItensGrid from '@/app/GerAdv_TS/DocsRecebidosItens/Crud/Grids/DocsRecebidosItensGrid';
export class DocsRecebidosItensGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <DocsRecebidosItensGrid />;
  }
}