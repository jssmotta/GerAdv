'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import CidadeGrid from '@/app/GerAdv_TS/Cidade/Crud/Grids/CidadeGrid';
export class CidadeGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <CidadeGrid />;
  }
}