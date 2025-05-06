import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProPartesInc from "../Inc/ProPartes";
import { IProPartes } from "../../Interfaces/interface.ProPartes";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProPartesEmpty } from "@/app/GerAdv_TS/Models/ProPartes";
import { useWindow } from "@/app/hooks/useWindows";

interface ProPartesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProPartes?: IProPartes;
    onSuccess: () => void;
    onError: () => void;
}

const ProPartesWindow: React.FC<ProPartesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProPartes,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/propartes/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProPartes?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProPartes]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProPartes?.id ?? 0).toString()}
                >
                    <ProPartesInc
                        id={selectedProPartes?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProPartes: React.FC<ProPartesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProPartesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProPartes={ProPartesEmpty()}>
        </ProPartesWindow>
    )
};

export default ProPartesWindow;