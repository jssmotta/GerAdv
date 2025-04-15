import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/EditWindow";
import AcaoInc from "../Inc/Acao";
import { IAcao } from "../../Interfaces/interface.Acao";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { AcaoEmpty } from "@/app/GerAdv_TS/Models/Acao";
import { useWindow } from "@/app/hooks/useWindows";

interface AcaoWindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedAcao?: IAcao;
    onSuccess: () => void;
    onError: () => void;
}

const AcaoWindow: React.FC<AcaoWindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedAcao,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/acao/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedAcao?.id}`);
        }

    }, [isMobile, router, selectedAcao]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? { width: 0, height: 0 }}
                    newHeight={445}
                    newWidth={720}
                    id={(selectedAcao?.id ?? 0).toString()}
                >
                    <AcaoInc
                        id={selectedAcao?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowAcao: React.FC<AcaoWindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <AcaoWindow
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedAcao={AcaoEmpty()}>
        </AcaoWindow>
    )
};

export default AcaoWindow;