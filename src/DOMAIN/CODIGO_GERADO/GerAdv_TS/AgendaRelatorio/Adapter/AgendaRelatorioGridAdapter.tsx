'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AgendaRelatorioGrid from '@/app/GerAdv_TS/AgendaRelatorio/Crud/Grids/AgendaRelatorioGrid';
export class AgendaRelatorioGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AgendaRelatorioGrid />;
  }
}