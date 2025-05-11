"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const Agenda2AgendaIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/Agenda2Agenda/Components/Agenda2AgendaIncContainer'),
  { ssr: false }
);

const Agenda2AgendaPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <Agenda2AgendaIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default Agenda2AgendaPageInc;