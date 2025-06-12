'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { CidadeGridAdapter } from '@/app/GerAdv_TS/Cidade/Adapter/CidadeGridAdapter';
import CidadeGridContainer from '@/app/GerAdv_TS/Cidade/Components/CidadeGridContainer';
const CidadePage: React.FC = () => {
  const CidadeGrid = new CidadeGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Cidade' />
    <CidadeGridContainer grid={CidadeGrid} />
  </PageLayout>
);
};
export default CidadePage;