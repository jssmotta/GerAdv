'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AgendaQuemGrid from '@/app/GerAdv_TS/AgendaQuem/Crud/Grids/AgendaQuemGrid';
export class AgendaQuemGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AgendaQuemGrid />;
  }
}