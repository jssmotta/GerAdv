import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import NEPalavrasChavesInc from "../Inc/NEPalavrasChaves";
import { INEPalavrasChaves } from "../../Interfaces/interface.NEPalavrasChaves";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { NEPalavrasChavesEmpty } from "@/app/GerAdv_TS/Models/NEPalavrasChaves";
import { useWindow } from "@/app/hooks/useWindows";

interface NEPalavrasChavesWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedNEPalavrasChaves?: INEPalavrasChaves;
    onSuccess: () => void;
    onError: () => void;
}

const NEPalavrasChavesWindow: React.FC<NEPalavrasChavesWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedNEPalavrasChaves,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/nepalavraschaves/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedNEPalavrasChaves?.id}`);
        }

    }, [isMobile, router, selectedNEPalavrasChaves]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedNEPalavrasChaves?.id ?? 0).toString()}
                >
                    <NEPalavrasChavesInc
                        id={selectedNEPalavrasChaves?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowNEPalavrasChaves: React.FC<NEPalavrasChavesWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <NEPalavrasChavesWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedNEPalavrasChaves={NEPalavrasChavesEmpty()}>
        </NEPalavrasChavesWindow>
    )
};

export default NEPalavrasChavesWindow;