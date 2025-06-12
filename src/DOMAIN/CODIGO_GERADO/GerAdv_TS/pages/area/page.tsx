'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AreaGridAdapter } from '@/app/GerAdv_TS/Area/Adapter/AreaGridAdapter';
import AreaGridContainer from '@/app/GerAdv_TS/Area/Components/AreaGridContainer';
const AreaPage: React.FC = () => {
  const AreaGrid = new AreaGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='Area' />
    <AreaGridContainer grid={AreaGrid} />
  </PageLayout>
);
};
export default AreaPage;