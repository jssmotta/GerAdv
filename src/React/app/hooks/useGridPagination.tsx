// useGridPagination.tsx
"use client";
import { useState } from 'react';
import { GridPageChangeEvent } from '@progress/kendo-react-grid';

interface UseGridPaginationProps {
  initialSkip?: number;
  initialTake?: number;
}

interface UseGridPaginationReturn {
  page: {
    skip: number;
    take: number;
  };
  handlePageChange: (event: GridPageChangeEvent) => void;
  setPage: React.Dispatch<React.SetStateAction<{ skip: number; take: number }>>;
}

export const useGridPagination = ({
  initialSkip = 0,
  initialTake = 10,
}: UseGridPaginationProps = {}): UseGridPaginationReturn => {
  const [page, setPage] = useState({
    skip: initialSkip,
    take: initialTake,
  });

  const handlePageChange = (event: GridPageChangeEvent) => {
    // Coerce values to numbers in case the Grid emits strings (select option values).
    const skip = Number(event.page.skip);
    const take = Number(event.page.take);

    setPage({
      skip: Number.isFinite(skip) ? skip : initialSkip,
      take: Number.isFinite(take) ? take : initialTake,
    });
  };

  return {
    page,
    handlePageChange,
    setPage,
  };
};