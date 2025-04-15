import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ProSucumbenciaInc from "../Inc/ProSucumbencia";
import { IProSucumbencia } from "../../Interfaces/interface.ProSucumbencia";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProSucumbenciaEmpty } from "@/app/GerAdv_TS/Models/ProSucumbencia";
import { useWindow } from "@/app/hooks/useWindows";

interface ProSucumbenciaWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProSucumbencia?: IProSucumbencia;
    onSuccess: () => void;
    onError: () => void;
}

const ProSucumbenciaWindow: React.FC<ProSucumbenciaWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProSucumbencia,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/prosucumbencia/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProSucumbencia?.id}`);
        }

    }, [isMobile, router, selectedProSucumbencia]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={699}
                    newWidth={720}
                    id={(selectedProSucumbencia?.id ?? 0).toString()}
                >
                    <ProSucumbenciaInc
                        id={selectedProSucumbencia?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProSucumbencia: React.FC<ProSucumbenciaWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProSucumbenciaWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProSucumbencia={ProSucumbenciaEmpty()}>
        </ProSucumbenciaWindow>
    )
};

export default ProSucumbenciaWindow;