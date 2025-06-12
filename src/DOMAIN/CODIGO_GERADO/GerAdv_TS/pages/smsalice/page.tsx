'use client';
import { PageLayout } from '@/app/components/Cruds/PageLayout';
import { PageTitle } from '@/app/components/PageTitle';
import { SMSAliceGridAdapter } from '@/app/GerAdv_TS/SMSAlice/Adapter/SMSAliceGridAdapter';
import SMSAliceGridContainer from '@/app/GerAdv_TS/SMSAlice/Components/SMSAliceGridContainer';
const SMSAlicePage: React.FC = () => {
  const SMSAliceGrid = new SMSAliceGridAdapter();
  return (
  <PageLayout>
    <PageTitle title='S M S Alice' />
    <SMSAliceGridContainer grid={SMSAliceGrid} />
  </PageLayout>
);
};
export default SMSAlicePage;