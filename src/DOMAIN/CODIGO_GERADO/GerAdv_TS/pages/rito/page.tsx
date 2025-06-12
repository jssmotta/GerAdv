'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { RitoGridAdapter } from '@/app/GerAdv_TS/Rito/Adapter/RitoGridAdapter';
import RitoGridContainer from '@/app/GerAdv_TS/Rito/Components/RitoGridContainer';
const RitoPage: React.FC = () => {
  const RitoGrid = new RitoGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Rito' />
    <RitoGridContainer grid={RitoGrid} />
  </PageLayout>
);
};
export default RitoPage;