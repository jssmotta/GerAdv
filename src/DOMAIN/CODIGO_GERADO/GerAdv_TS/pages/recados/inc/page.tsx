"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/paginas/DrawerLayout';
import { LoadingSpinner } from "@/app/components/LoadingSpinner";
import dynamic from 'next/dynamic';

const RecadosIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/Recados/Components/RecadosIncContainer'),
  { ssr: false }
);

const RecadosPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <RecadosIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default RecadosPageInc;