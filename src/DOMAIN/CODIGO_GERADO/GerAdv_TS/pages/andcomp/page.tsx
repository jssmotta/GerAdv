'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { AndCompGridAdapter } from '@/app/GerAdv_TS/AndComp/Adapter/AndCompGridAdapter';
import AndCompGridContainer from '@/app/GerAdv_TS/AndComp/Components/AndCompGridContainer';
const AndCompPage: React.FC = () => {
  const AndCompGrid = new AndCompGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='And Comp' />
    <AndCompGridContainer grid={AndCompGrid} />
  </PageLayout>
);
};
export default AndCompPage;