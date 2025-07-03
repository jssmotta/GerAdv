// CidadeGridContainer.test.tsx
import React from 'react';
import { render, screen } from '@testing-library/react';
import { IGridComponent } from '@/app/interfaces/IGridComponent';
import CidadeGridContainer from '@/app/GerAdv_TS/Cidade/Components/CidadeGridContainer';
describe('CidadeGridContainer', () => {
  it('renders the grid component output', () => {
    // Mock grid with a render method
    const mockGrid: IGridComponent = {
      render: () => <div data-testid='mock-grid'>Mock Grid Content</div>
    };
    render(<CidadeGridContainer grid={mockGrid} />);
    // Assert the mock grid content is rendered
    expect(screen.getByTestId('mock-grid')).toHaveTextContent('Mock Grid Content');
  });
});