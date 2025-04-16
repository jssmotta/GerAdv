import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import PrepostosInc from "../Inc/Prepostos";
import { IPrepostos } from "../../Interfaces/interface.Prepostos";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { PrepostosEmpty } from "@/app/GerAdv_TS/Models/Prepostos";
import { useWindow } from "@/app/hooks/useWindows";

interface PrepostosWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedPrepostos?: IPrepostos;
    onSuccess: () => void;
    onError: () => void;
}

const PrepostosWindow: React.FC<PrepostosWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedPrepostos,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/prepostos/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedPrepostos?.id}`);
        }

    }, [isMobile, router, selectedPrepostos]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={905}
                    newWidth={1440}
                    id={(selectedPrepostos?.id ?? 0).toString()}
                >
                    <PrepostosInc
                        id={selectedPrepostos?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowPrepostos: React.FC<PrepostosWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <PrepostosWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedPrepostos={PrepostosEmpty()}>
        </PrepostosWindow>
    )
};

export default PrepostosWindow;