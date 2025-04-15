"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/paginas/DrawerLayout';
import { LoadingSpinner } from "@/app/components/LoadingSpinner";
import dynamic from 'next/dynamic';

const FuncaoIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/Funcao/Components/FuncaoIncContainer'),
  { ssr: false }
);

const FuncaoPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <FuncaoIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default FuncaoPageInc;