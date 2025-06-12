'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProcessosParadosGrid from '@/app/GerAdv_TS/ProcessosParados/Crud/Grids/ProcessosParadosGrid';
export class ProcessosParadosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProcessosParadosGrid />;
  }
}