'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import EventoPrazoAgendaGrid from '@/app/GerAdv_TS/EventoPrazoAgenda/Crud/Grids/EventoPrazoAgendaGrid';
export class EventoPrazoAgendaGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <EventoPrazoAgendaGrid />;
  }
}