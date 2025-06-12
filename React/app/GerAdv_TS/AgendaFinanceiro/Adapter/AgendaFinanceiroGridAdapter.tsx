'use client';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import AgendaFinanceiroGrid from '@/app/GerAdv_TS/AgendaFinanceiro/Crud/Grids/AgendaFinanceiroGrid';
export class AgendaFinanceiroGridAdapter implements IGridComponent {
  render(): React.ReactNode {
    return <AgendaFinanceiroGrid />;
  }
}