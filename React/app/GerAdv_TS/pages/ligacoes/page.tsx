'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { LigacoesGridAdapter } from '@/app/GerAdv_TS/Ligacoes/Adapter/LigacoesGridAdapter';
import LigacoesGridContainer from '@/app/GerAdv_TS/Ligacoes/Components/LigacoesGridContainer';
const LigacoesPage: React.FC = () => {
  const LigacoesGrid = new LigacoesGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Ligacoes' />
    <LigacoesGridContainer grid={LigacoesGrid} />
  </PageLayout>
);
};
export default LigacoesPage;