'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AnexamentoRegistrosGridAdapter } from '@/app/GerAdv_TS/AnexamentoRegistros/Adapter/AnexamentoRegistrosGridAdapter';
import AnexamentoRegistrosGridContainer from '@/app/GerAdv_TS/AnexamentoRegistros/Components/AnexamentoRegistrosGridContainer';
const AnexamentoRegistrosPage: React.FC = () => {
  const AnexamentoRegistrosGrid = new AnexamentoRegistrosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Anexamento Registros' />
    <AnexamentoRegistrosGridContainer grid={AnexamentoRegistrosGrid} />
  </PageLayout>
);
};
export default AnexamentoRegistrosPage;