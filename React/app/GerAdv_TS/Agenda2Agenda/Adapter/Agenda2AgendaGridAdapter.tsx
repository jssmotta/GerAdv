'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import Agenda2AgendaGrid from '@/app/GerAdv_TS/Agenda2Agenda/Crud/Grids/Agenda2AgendaGrid';
export class Agenda2AgendaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <Agenda2AgendaGrid />;
  }
}