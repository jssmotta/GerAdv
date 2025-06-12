'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { ParteClienteOutrasGridAdapter } from '@/app/GerAdv_TS/ParteClienteOutras/Adapter/ParteClienteOutrasGridAdapter';
import ParteClienteOutrasGridContainer from '@/app/GerAdv_TS/ParteClienteOutras/Components/ParteClienteOutrasGridContainer';
const ParteClienteOutrasPage: React.FC = () => {
  const ParteClienteOutrasGrid = new ParteClienteOutrasGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Parte Cliente Outras' />
    <ParteClienteOutrasGridContainer grid={ParteClienteOutrasGrid} />
  </PageLayout>
);
};
export default ParteClienteOutrasPage;