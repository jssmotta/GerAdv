'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AgendaFinanceiroGridAdapter } from '@/app/GerAdv_TS/AgendaFinanceiro/Adapter/AgendaFinanceiroGridAdapter';
import AgendaFinanceiroGridContainer from '@/app/GerAdv_TS/AgendaFinanceiro/Components/AgendaFinanceiroGridContainer';
const AgendaFinanceiroPage: React.FC = () => {
  const AgendaFinanceiroGrid = new AgendaFinanceiroGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Agenda Financeiro' />
    <AgendaFinanceiroGridContainer grid={AgendaFinanceiroGrid} />
  </PageLayout>
);
};
export default AgendaFinanceiroPage;