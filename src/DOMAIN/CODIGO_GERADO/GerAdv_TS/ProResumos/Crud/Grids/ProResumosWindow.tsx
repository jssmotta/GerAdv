import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import ProResumosInc from "../Inc/ProResumos";
import { IProResumos } from "../../Interfaces/interface.ProResumos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { ProResumosEmpty } from "@/app/GerAdv_TS/Models/ProResumos";
import { useWindow } from "@/app/hooks/useWindows";

interface ProResumosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedProResumos?: IProResumos;
    onSuccess: () => void;
    onError: () => void;
}

const ProResumosWindow: React.FC<ProResumosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedProResumos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/proresumos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedProResumos?.id}`);
        }

    }, [isMobile, router, selectedProResumos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedProResumos?.id ?? 0).toString()}
                >
                    <ProResumosInc
                        id={selectedProResumos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowProResumos: React.FC<ProResumosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <ProResumosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedProResumos={ProResumosEmpty()}>
        </ProResumosWindow>
    )
};

export default ProResumosWindow;