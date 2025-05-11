"use client";
import React from "react";
import { useIdParam } from "@/app/hooks/useIdParam";
import { NextNavigationService } from "@/app/services/NavigationService";
import { useRouter } from "next/navigation";
import Layout from '@/app/components/DrawerLayout';
import { LoadingSpinner } from "@/app/components/Cruds/LoadingSpinner";
import dynamic from 'next/dynamic';

const OperadorEMailPopupIncContainer = dynamic(
  () => import('@/app/GerAdv_TS/OperadorEMailPopup/Components/OperadorEMailPopupIncContainer'),
  { ssr: false }
);

const OperadorEMailPopupPageInc: React.FC = () => {
    const router = useRouter();
    const id = useIdParam();
    const navigator = React.useMemo(() => new NextNavigationService(router), [router]);       

    return (
        <Layout>
            {id === null ? (
                <LoadingSpinner />
            ) : (
                <OperadorEMailPopupIncContainer id={id} navigator={navigator} />
            )}
        </Layout>
    );
};

export default OperadorEMailPopupPageInc;