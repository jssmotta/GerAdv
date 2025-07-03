import React from 'react';
import { render } from '@testing-library/react';
import StatusHTrabIncContainer from '@/app/GerAdv_TS/StatusHTrab/Components/StatusHTrabIncContainer';
// StatusHTrabIncContainer.test.tsx
// Mock do StatusHTrabInc
jest.mock('@/app/GerAdv_TS/StatusHTrab/Crud/Inc/StatusHTrab', () => (props: any) => (
<div data-testid='statushtrab-inc-mock' {...props} />
));
describe('StatusHTrabIncContainer', () => {
  it('deve renderizar StatusHTrabInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <StatusHTrabIncContainer id={id} navigator={mockNavigator} />
  );
  const statushtrabInc = getByTestId('statushtrab-inc-mock');
  expect(statushtrabInc).toBeInTheDocument();
  expect(statushtrabInc.getAttribute('id')).toBe(id.toString());

});
});