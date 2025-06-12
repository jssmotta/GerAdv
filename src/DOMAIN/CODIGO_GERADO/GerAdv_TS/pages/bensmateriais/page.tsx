'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { BensMateriaisGridAdapter } from '@/app/GerAdv_TS/BensMateriais/Adapter/BensMateriaisGridAdapter';
import BensMateriaisGridContainer from '@/app/GerAdv_TS/BensMateriais/Components/BensMateriaisGridContainer';
const BensMateriaisPage: React.FC = () => {
  const BensMateriaisGrid = new BensMateriaisGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Bens Materiais' />
    <BensMateriaisGridContainer grid={BensMateriaisGrid} />
  </PageLayout>
);
};
export default BensMateriaisPage;