'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { CargosGridAdapter } from '@/app/GerAdv_TS/Cargos/Adapter/CargosGridAdapter';
import CargosGridContainer from '@/app/GerAdv_TS/Cargos/Components/CargosGridContainer';
const CargosPage: React.FC = () => {
  const CargosGrid = new CargosGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Cargos' />
    <CargosGridContainer grid={CargosGrid} />
  </PageLayout>
);
};
export default CargosPage;