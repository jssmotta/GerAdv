﻿import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import RitoInc from "../Inc/Rito";
import { IRito } from "../../Interfaces/interface.Rito";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { RitoEmpty } from "@/app/GerAdv_TS/Models/Rito";
import { useWindow } from "@/app/hooks/useWindows";

interface RitoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedRito?: IRito;
    onSuccess: () => void;
    onError: () => void;
}

const RitoWindow: React.FC<RitoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedRito,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/rito/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedRito?.id}`);
        }

    }, [isMobile, router, selectedRito]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedRito?.id ?? 0).toString()}
                >
                    <RitoInc
                        id={selectedRito?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowRito: React.FC<RitoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <RitoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedRito={RitoEmpty()}>
        </RitoWindow>
    )
};

export default RitoWindow;