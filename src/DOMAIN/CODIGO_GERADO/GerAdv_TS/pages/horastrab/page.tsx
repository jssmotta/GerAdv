'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { HorasTrabGridAdapter } from '@/app/GerAdv_TS/HorasTrab/Adapter/HorasTrabGridAdapter';
import HorasTrabGridContainer from '@/app/GerAdv_TS/HorasTrab/Components/HorasTrabGridContainer';
const HorasTrabPage: React.FC = () => {
  const HorasTrabGrid = new HorasTrabGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Horas Trab' />
    <HorasTrabGridContainer grid={HorasTrabGrid} />
  </PageLayout>
);
};
export default HorasTrabPage;