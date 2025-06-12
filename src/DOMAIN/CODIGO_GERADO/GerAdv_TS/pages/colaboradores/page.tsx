'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ColaboradoresGridAdapter } from '@/app/GerAdv_TS/Colaboradores/Adapter/ColaboradoresGridAdapter';
import ColaboradoresGridContainer from '@/app/GerAdv_TS/Colaboradores/Components/ColaboradoresGridContainer';
const ColaboradoresPage: React.FC = () => {
  const ColaboradoresGrid = new ColaboradoresGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Colaboradores' />
    <ColaboradoresGridContainer grid={ColaboradoresGrid} />
  </PageLayout>
);
};
export default ColaboradoresPage;