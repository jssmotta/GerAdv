'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { DocsRecebidosItensGridAdapter } from '@/app/GerAdv_TS/DocsRecebidosItens/Adapter/DocsRecebidosItensGridAdapter';
import DocsRecebidosItensGridContainer from '@/app/GerAdv_TS/DocsRecebidosItens/Components/DocsRecebidosItensGridContainer';
const DocsRecebidosItensPage: React.FC = () => {
  const DocsRecebidosItensGrid = new DocsRecebidosItensGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Docs Recebidos Itens' />
    <DocsRecebidosItensGridContainer grid={DocsRecebidosItensGrid} />
  </PageLayout>
);
};
export default DocsRecebidosItensPage;