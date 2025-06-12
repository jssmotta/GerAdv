'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { OutrasPartesClienteGridAdapter } from '@/app/GerAdv_TS/OutrasPartesCliente/Adapter/OutrasPartesClienteGridAdapter';
import OutrasPartesClienteGridContainer from '@/app/GerAdv_TS/OutrasPartesCliente/Components/OutrasPartesClienteGridContainer';
const OutrasPartesClientePage: React.FC = () => {
  const OutrasPartesClienteGrid = new OutrasPartesClienteGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Outras Partes Cliente' />
    <OutrasPartesClienteGridContainer grid={OutrasPartesClienteGrid} />
  </PageLayout>
);
};
export default OutrasPartesClientePage;