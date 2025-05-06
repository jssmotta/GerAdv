"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/paginas/DrawerLayout';
import { LoadingSpinner } from "@/app/components/LoadingSpinner";
import dynamic from 'next/dynamic';

const OperadorGruposAgendaIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/OperadorGruposAgenda/Components/OperadorGruposAgendaIncContainer'),
  { ssr: false }
);

const OperadorGruposAgendaPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <OperadorGruposAgendaIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default OperadorGruposAgendaPageInc;