"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const ProPartesIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/ProPartes/Components/ProPartesIncContainer'),
  { ssr: false }
);

const ProPartesPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <ProPartesIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default ProPartesPageInc;