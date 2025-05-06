import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import CidadeInc from "../Inc/Cidade";
import { ICidade } from "../../Interfaces/interface.Cidade";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { CidadeEmpty } from "@/app/GerAdv_TS/Models/Cidade";
import { useWindow } from "@/app/hooks/useWindows";

interface CidadeWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedCidade?: ICidade;
    onSuccess: () => void;
    onError: () => void;
}

const CidadeWindow: React.FC<CidadeWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedCidade,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/cidade/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedCidade?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedCidade]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={699}
                    newWidth={720}
                    id={(selectedCidade?.id ?? 0).toString()}
                >
                    <CidadeInc
                        id={selectedCidade?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowCidade: React.FC<CidadeWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <CidadeWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedCidade={CidadeEmpty()}>
        </CidadeWindow>
    )
};

export default CidadeWindow;