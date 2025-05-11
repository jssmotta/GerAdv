import React, { useEffect } from "react";
import { EditWindow } from "@/app/components/Cruds/EditWindow";
import Diario2Inc from "../Inc/Diario2";
import { IDiario2 } from "../../Interfaces/interface.Diario2";
import { useIsMobile } from "@/app/context/MobileContext";
import { useRouter } from "next/navigation";
import { Diario2Empty } from "@/app/GerAdv_TS/Models/Diario2";
import { useWindow } from "@/app/hooks/useWindows";

interface Diario2WindowProps {
    isOpen: boolean;
    onClose: () => void;
    dimensions?: { width: number; height: number };    
    selectedDiario2?: IDiario2;
    onSuccess: () => void;
    onError: () => void;
}

const Diario2Window: React.FC<Diario2WindowProps> = ({
    isOpen,
    onClose,
    dimensions,    
    selectedDiario2,
    onSuccess,
    onError,
}) => {

    const router = useRouter();
    const isMobile = useIsMobile();
    const dimensionsEmpty = useWindow();

    useEffect(() => {
        if (!isOpen) return;
        if (isMobile) {
            router.push(`/pages/diario2/inc${process.env.NEXT_PUBLIC_PAGE_HTML ?? ''}?id=${selectedDiario2?.id ?? '0'}`);
        }

    }, [isMobile, router, selectedDiario2]);

    return (
        <>
            {isMobile || !isOpen ? <></> : <>
                <EditWindow
                    isOpen={isOpen}
                    onClose={onClose}
                    dimensions={dimensions ?? dimensionsEmpty}
                    newHeight={633}
                    newWidth={720}
                    id={(selectedDiario2?.id ?? 0).toString()}
                >
                    <Diario2Inc
                        id={selectedDiario2?.id ?? 0}
                        onClose={onClose}
                        onSuccess={onSuccess}
                        onError={onError}
                    />
                </EditWindow>
            </>}
        </>
    );
};

export const NewWindowDiario2: React.FC<Diario2WindowProps> = ({
    isOpen,
    onClose,
}) => {

    const dimensions = useWindow();
    return (
        <Diario2Window
            isOpen={isOpen}
            onClose={onClose}
            dimensions={dimensions}          
            onSuccess={onClose}
            onError={onClose}
            selectedDiario2={Diario2Empty()}>
        </Diario2Window>
    )
};

export default Diario2Window;