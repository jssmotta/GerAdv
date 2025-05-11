"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const LivroCaixaIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/LivroCaixa/Components/LivroCaixaIncContainer'),
  { ssr: false }
);

const LivroCaixaPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <LivroCaixaIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default LivroCaixaPageInc;