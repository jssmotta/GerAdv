"use client";
import { PageLayout } from "@/app/components/PageLayout"; 
import { PageTitle } from "@/app/components/PageTitle"; 
import { AlarmSMSGridAdapter } from "@/app/GerAdv_TS/AlarmSMS/Adapter/AlarmSMSGridAdapter";
import AlarmSMSGridContainer from "@/app/GerAdv_TS/AlarmSMS/Components/AlarmSMSGridContainer";

const AlarmSMSPage: React.FC = () => {
    const AlarmSMSGrid = new AlarmSMSGridAdapter();

    return (
        <PageLayout>
            <PageTitle title="Alarm S M S" />
            <AlarmSMSGridContainer grid={AlarmSMSGrid} />
        </PageLayout>
    );
};

export default AlarmSMSPage;