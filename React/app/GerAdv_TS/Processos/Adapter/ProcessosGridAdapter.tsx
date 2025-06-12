'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import ProcessosGrid from '@/app/GerAdv_TS/Processos/Crud/Grids/ProcessosGrid';
export class ProcessosGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <ProcessosGrid />;
  }
}