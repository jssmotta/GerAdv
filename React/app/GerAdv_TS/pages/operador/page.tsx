'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { OperadorGridAdapter } from '@/app/GerAdv_TS/Operador/Adapter/OperadorGridAdapter';
import OperadorGridContainer from '@/app/GerAdv_TS/Operador/Components/OperadorGridContainer';
const OperadorPage: React.FC = () => {
  const OperadorGrid = new OperadorGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Operador' />
    <OperadorGridContainer grid={OperadorGrid} />
  </PageLayout>
);
};
export default OperadorPage;