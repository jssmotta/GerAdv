'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import EscritoriosGrid from '@/app/GerAdv_TS/Escritorios/Crud/Grids/EscritoriosGrid';
export class EscritoriosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <EscritoriosGrid />;
  }
}