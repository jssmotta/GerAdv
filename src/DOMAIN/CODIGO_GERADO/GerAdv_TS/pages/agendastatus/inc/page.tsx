"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const AgendaStatusIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/AgendaStatus/Components/AgendaStatusIncContainer'),
  { ssr: false }
);

const AgendaStatusPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <AgendaStatusIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default AgendaStatusPageInc;