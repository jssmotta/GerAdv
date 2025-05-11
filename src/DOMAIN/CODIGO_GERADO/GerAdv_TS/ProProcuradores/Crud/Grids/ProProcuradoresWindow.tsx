import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import ProProcuradoresInc from "../Inc/ProProcuradores";
import { IProProcuradores } from "../../Interfaces/interface.ProProcuradores";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProProcuradoresEmpty } from "@/app/GerAdv_TS/Models/ProProcuradores";
import { useWindow } from "@/app/hooks/useWindows";

interface ProProcuradoresWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProProcuradores?: IProProcuradores;
    onSuccess: () => void;
    onError: () => void;
}

const ProProcuradoresWindow: React.FC<ProProcuradoresWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProProcuradores,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/proprocuradores/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProProcuradores?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedProProcuradores]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={633}
                    newWidth={720}
                    id={(selectedProProcuradores?.id ?? 0).toString()}
                >
                    <ProProcuradoresInc
                        id={selectedProProcuradores?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProProcuradores: React.FC<ProProcuradoresWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProProcuradoresWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProProcuradores={ProProcuradoresEmpty()}>
        </ProProcuradoresWindow>
    )
};

export default ProProcuradoresWindow;